// Variable declaration
var a = 1; // legacy
let b = "2";
const c = true; // cannot change value after declaration
b = 4; // no type check
b = 4 + '4' // even it's possible, equals to '44'

if (a == b) { // equal operator
	// action
} else if (b === c) { //strict equal operator
	// action
} else {
	// action
}

while (a) { //every value in JS is truthy or falsy
	// do action
}

// falsy
undefined;
null;
false;
0;
false;
"";
NaN;

const str1 = "string"; // this is string
const str2 = 'string'; // this is string as well

str1 === str2; // true

const arr = [1, 1.2, true, undefined, null, [1, 3, 5]]; // this is array
arr.concat(5, 6, 7); // concat array with numbers
arr.findIndex(1); // returns 0, if it returns -1 -  element not found
arr.push(5); // add element to array

const obj = {
	a: '1',
	b: 2,
	[a]: 4,
	c: {
		a: [1, 2, 3]
	}
}

obj.a; // returns '1'
obj['a']; // returns '1'

function some() { 
	console.log('Hello, world');
	return 42;
}

const func1 = function(a, b, c) {
	return a + b + c;
}

const func2 = (a, b, c) => a + b + c;

func1(1, 2, 3); // 6
func2(1, 2, 3); // 6

