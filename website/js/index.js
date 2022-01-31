let clickTimes = 0;

const clickedTimesId = 'clickedTimes';
const clickedTimeEl = document.getElementById(clickedTimesId);

const clickBtnId = 'clickButton';
const clickBtn = document.getElementById(clickBtnId);
clickBtn.onclick = () => clickedTimeEl.innerHTML = ++clickTimes;

// table handler
const addBtn = document.getElementById('addButton');
const dataInputRow = document.getElementById('dataInputRow');
const addBtnRow = document.getElementById('addBtnRow');

const showInputs = () => {
	dataInputRow.style.display = 'table-row';
	addBtnRow.style.display = 'none';
};

const hideInputs = () => {
	dataInputRow.style.display = 'none';
	addBtnRow.style.display = 'table-row';
};

addBtn.onclick = showInputs

let id = 0;
const addToTable = (row) => {
	const tr = document.createElement('tr');

	const idElement = document.createElement('td');
	idElement.innerText = ++id;

	const firstNameElem = document.createElement('td');
	firstNameElem.innerText = row.firstName;

	const lastNameElem = document.createElement('td');
	lastNameElem.innerText = row.lastName;

	const handleElem = document.createElement('td');
	handleElem.innerText = row.handle;

	tr.appendChild(idElement);
	tr.appendChild(firstNameElem);
	tr.appendChild(lastNameElem);
	tr.appendChild(handleElem);

	const usersDataBody = document.querySelector('#usersData tbody');
	usersDataBody.prepend(tr);
}

const inputs = document.querySelectorAll('#dataInputRow input');

const clearInputs = () => {
	inputs.forEach((input) => input.value = '');
}

const keyPressHandler = (event) => {
	const key = event.key;
	if (key === 'Enter') {
		const arg = {};
		inputs.forEach(input => {
			arg[input.id] = input.value;
		});

		addToTable(arg);
		hideInputs();
		clearInputs();
	}
}

inputs.forEach((input) => {
	input.onkeypress = keyPressHandler;
});
