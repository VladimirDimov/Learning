var item = (function() {
   'use strict';
    
    var item = {
        init: function(value) {
            this.value = value;
            this.children = [];
            
            return this;
        },
        
        get value() {
          return this._value;  
        },
        
        set value(value) {
            this._value = value;
        },
        
        get children() {
            return this._children;
        },
        
        set children(value) {
            this._children = value;
        }        
    };
    
    return item;
}());