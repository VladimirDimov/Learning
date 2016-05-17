var superArray = (function() {
   'use strict';
    var superArray = Object.create(Array.prototype);
    
    Object.defineProperties(superArray, {
        toString: {
            value: function(){
                return this.join('==');
            }
        }
    });
    
    return superArray;
}());