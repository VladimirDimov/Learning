var heap = heap.init(function(right, left) {
    return right < left;
});

heap.push(10);  
heap.push(5);  
heap.push(4);  
heap.push(20);  
heap.push(300);
heap.push(300);
heap.push(1);  
heap.push(1);  
heap.push(150);
heap.push(7);  
heap.push(100);
heap.push(30);  
heap.push(2);

// heap.push('sdf');
// heap.push('sfsdafd');
// heap.push('sdf');
// heap.push('d');

console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());
console.log(heap.pop());