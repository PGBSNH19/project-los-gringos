document.getElementById('inviteByEmailBtn').addEventListener('click', () => {
    const link = location.href;

    window.open(`mailto: ?body= join me at the pub just press the link below!  ${link}"> `);
})