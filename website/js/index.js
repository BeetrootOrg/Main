let clickTimes = 0;

const clickedTimesId = 'clickedTimes';
const clickedTimeEl = document.getElementById(clickedTimesId);

const clickBtnId = 'clickButton';
const clickBtn = document.getElementById(clickBtnId);
clickBtn.onclick = () => clickedTimeEl.innerHTML = ++clickTimes;
