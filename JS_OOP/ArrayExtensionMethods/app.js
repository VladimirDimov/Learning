var superArr = Object.create(superArray);

for (var index = 0; index < 10; index++) {
    superArr.push(index);    
}

console.log(superArr.toString());