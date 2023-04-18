window.getFromStorage = (key) => {
    return localStorage.getItem(key);
}

window.setToStorage = (key, value) => {
    localStorage.setItem(key, value);
}