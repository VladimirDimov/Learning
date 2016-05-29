var dragAndDrop = function (settings) {
    var dragables = Array.prototype.slice.apply(document.querySelectorAll(settings.dragables));
    var dropzones = Array.prototype.slice.apply(document.querySelectorAll(settings.dropzones));
    var elements = [];

    var validators = {
        validateNotNull: function (element, name) {
            if (!element) throw new Error((name || 'Unspecified') + ' cannot be null.');
        },

        validateIsObject: function (element, name) {
            if (typeof element !== 'object') throw new Error((name || 'Unspecified') + ' must be an object.')
        },

        validateNonNullObject: function (element, name) {
            this.validateNotNull(element, name);
            this.validateIsObject(element, name);
        }
    }

    var stylesFormatter = {
        dropzoneDragOver: function (element) {
            element.style.outline = 'yellow solid thick';
        },

        dropzoneDragLeave: function (element) {
            element.style.outline = '';
        },

        dropzoneDrop: function (element) {
            this.dropzoneDragLeave(element);
        },
        
        fadeIn: function(element, opacity, milliseconds) {
            var curOpacity = 0;
            element.style.opacity = 0;
            
            var fadeIn = setInterval(function() {
                curOpacity += 0.02;
                element.style.opacity = curOpacity;
                if(element.style.opacity >= opacity) clearInterval(fadeIn);
            }, 120)
        }
    };

    var helpers = {
        removeFromCollection(collection, element, collectionName) {
            validators.validateNonNullObject(collection, collectionName);
            var index = collection.findIndex(function (el) {
                return el === element;
            });

            if (index !== -1) {
                collection.splice(index, 1);
            }
        },

        addToCollectionIfNotContains(collection, element, callback) {
            var index = collection.findIndex(callback);
            if (index === -1) {
                collection.push(element);
                return collection.length - 1;
            }

            return index;
        },

        wrapNode: function (element, wrapper) {
            wrapper.appendChild(element);
        }
    };

    var nodeProvider = {
        getThumbnailWrapper: function () {
            var thumbnail = document.createElement('div');
            thumbnail.className += 'thumbnail';

            return thumbnail;
        },

        removeNode: function (node) {
            node.parentNode.removeChild(node);
        }
    };

    (function setDragables() {
        dragables.forEach(function (dragable) {
            dragable.setAttribute('draggable', 'true');

            dragable.addEventListener('dragstart', function (e) {
                var index = helpers.addToCollectionIfNotContains(elements, { element: e.target, parentNode: e.target.parentNode }, function (element) {
                    return element.element === e.target;
                });

                if (index !== -1) {
                    e.dataTransfer.setData('text', index);
                }
            });

            dragable.addEventListener('dragenter', function (e) {
                e.preventDefault();
            });

        }, this);
    })();

    (function setDropzones() {
        dropzones.forEach(function (dropzone) {
            dropzone.addEventListener('dragleave', function (e) {
                stylesFormatter.dropzoneDragLeave(dropzone);
            });

            dropzone.addEventListener('dragover', function (e) {
                e.preventDefault();
                // dropzone.style.backgroundColor = 'gray';
                stylesFormatter.dropzoneDragOver(dropzone);
            }, false);

            dropzone.addEventListener('drop', function (e) {

                e.preventDefault();
                var dragIndex = e.dataTransfer.getData('text');
                var droppedElement = elements[parseInt(dragIndex)];
                if (droppedElement.dropZone !== this) {
                    if (droppedElement.dropZone) {
                        deleteFromPreviousDropzone(droppedElement.element);
                    }

                    var thumbnail = nodeProvider.getThumbnailWrapper();
                    thumbnail.appendChild(droppedElement.element);
                    droppedElement.dropZone = this;
                    this.appendChild(thumbnail);
                    stylesFormatter.fadeIn(droppedElement.element, 0.5, 1000);
                }

                stylesFormatter.dropzoneDrop(dropzone);
            });

            dropzone.addEventListener('click', function (e) {
                var target = e.target;
                while (target.className.indexOf('thumbnail') === -1) {
                    target = target.parentNode;
                }

                if (target != null) {
                    moveElementBack(target.firstChild);
                    nodeProvider.removeNode(target);
                }
            });

            function deleteFromPreviousDropzone(element) {
                var thumbnail = element.parentNode;
                nodeProvider.removeNode(element);
                nodeProvider.removeNode(thumbnail);
            }

            function moveElementBack(el) {
                var dropedElement = elements.find(function (element) {
                    return element.element == el;
                });

                if (dropedElement) {
                    el.parentNode.removeChild(el);
                    dropedElement.parentNode.appendChild(dropedElement.element);
                    helpers.removeFromCollection(elements, dropedElement, 'Dropped elements collection');
                }
            }
        });
    })();
}