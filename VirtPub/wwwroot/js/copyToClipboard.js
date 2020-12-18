const link = location.href;
document.getElementById("invite-link").innerHTML = link;
inviteLink()

function inviteLink() {
    const copyInviteBtn = document.getElementById('inviteBtn');

    copyInviteBtn.addEventListener('click', () => {
        const inviteLink = document.getElementById('invite-link');
        const range = document.createRange();
        range.selectNode(inviteLink);
        window.getSelection().addRange(range);

        window.getSelection().removeAllRanges();
    });
}

