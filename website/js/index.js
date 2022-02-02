const emailInput = document.getElementById('emailInput');
const passwordInput = document.getElementById('passwordInput');
const rememberMeCheck = document.getElementById('rememberMeCheck');
const submitForm = document.getElementById('submitForm');

let id = 0;
submitForm.onclick = () => {
	const email = emailInput.value;
	const password = passwordInput.value;
	const rememberMe = rememberMeCheck.checked;

	const creds = {
		email,
		password,
		rememberMe
	}

	localStorage.setItem(`credentials${id++}`, JSON.stringify(creds));
}