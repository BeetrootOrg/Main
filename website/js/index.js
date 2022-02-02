const emailInput = document.getElementById('emailInput');
const passwordInput = document.getElementById('passwordInput');
const rememberMeCheck = document.getElementById('rememberMeCheck');
const submitForm = document.getElementById('submitForm');
const loginForm = document.getElementById('loginForm');
const signInBlock = document.getElementById('signInBlock');
const userEmail = document.getElementById('userEmail');
const passwordLength = document.getElementById('passwordLength');

const hideLogin = () => {
	loginForm.style.display = 'none';
};

const showSignIn = () => {
	signInBlock.style.display = 'block';
};

const signIn = (creds) => {
	localStorage.setItem('credentials', JSON.stringify(creds));
};

const restoreCreds = () => {
	const creds = JSON.parse(localStorage.getItem('credentials'));

	userEmail.innerText = creds.email;
	passwordLength.innerText = creds.password.length;
};

submitForm.onclick = () => {
	const email = emailInput.value;
	const password = passwordInput.value;
	const rememberMe = rememberMeCheck.checked;

	const creds = {
		email,
		password,
		rememberMe
	}

	signIn(creds);
	restoreCreds();
	hideLogin();
	showSignIn();
};

if (localStorage.getItem('credentials')) {
	restoreCreds();
	hideLogin();
	showSignIn();
}