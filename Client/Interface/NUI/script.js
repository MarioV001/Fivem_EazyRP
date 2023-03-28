window.addEventListener('message', (event) => {
    const data = event.data;
    if (data.type === 'playerName') {
        document.getElementById('Welcome_head').innerHTML = '<h2>Welcome ' + data.data + ' to EazyRP</h2>';
    }
});