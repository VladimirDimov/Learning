var dragAndDrop = function (settings) {
    var dragables = Array.prototype.slice.apply(document.querySelectorAll(settings.dragables));
    var dropzones = Array.prototype.slice.apply(document.querySelectorAll(settings.dropzones));
    var elements = [];

    dragables.forEach(function (dragable) {
        dragable.setAttribute('draggable', 'true');

        dragable.addEventListener('dragstart', function (e) {
            var index = elements.indexOf(e.target);
            if (index == -1) {
                elements.push(e.target);
                index = elements.length - 1;
            }

            e.dataTransfer.setData('text', index);
        });

        dragable.addEventListener('dragenter', function (e) {
            e.preventDefault();
        });
    }, this);

    dropzones.forEach(function (dropzone) {
        dropzone.addEventListener('dragleave', function (e) {
            dropzone.style.backgroundColor = '';
        });

        dropzone.addEventListener('dragover', function (e) {
            e.preventDefault();
            dropzone.style.backgroundColor = 'grey';
        }, false);

        dropzone.addEventListener('drop', function (e) {
            var dragIndex = e.dataTransfer.getData('text');
            this.appendChild(elements[parseInt(dragIndex)]);
            dropzone.style.backgroundColor = '';
        });
    });
}