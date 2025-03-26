function lockedProfile() {
    const profileAPI = 'http://localhost:3030/jsonstore/advanced/profiles'
    const main = document.querySelector('#main')
    main.innerHTML = ''

    const toggleHiddenFields = (btnText, style, e) => {
        const hiddenFields = e.parentElement.querySelector('#user1HiddenFields')
        hiddenFields.style.display = style
        e.textContent = btnText
    }

    const btnShow = (e) => {
        const parentElement = e.parentElement
        const unlock = parentElement.querySelector('input[value="unlock"]')


        if (unlock.checked && e.textContent === 'Show more') {
            toggleHiddenFields('Hide it', 'inline-block', e)
        } else if (unlock.checked) {
            toggleHiddenFields('Show more', 'none', e)
        }
    }

    fetch(profileAPI).then(x => x.json())
        .then(o => {
            Object.values(o).forEach(x => {
                main.innerHTML += `
            <div class="profile">
                <img src="./iconProfile2.png" class="userIcon" alt="prifile pic"/>
                <label>Lock</label>
                <input type="radio" name="user1Locked" value="lock" checked>
                <label>Unlock</label>
                <input type="radio" name="user1Locked" value="unlock"><br>
                <hr>
                <label>Username</label>
                <input type="text" name="user1Username" value="${x.username}" disabled readonly />
                <div id="user1HiddenFields" style="display: none">
                    <hr>
                    <label>Email:</label>
                    <input type="email" name="user1Email" value="${x.email}" disabled readonly />
                    <label>Age:</label>
                    <input type="email" name="user1Age" value="${x.age}" disabled readonly />
                </div>
            <button onclick="funcJS.btnShow(this)">Show more</button>
            </div>`
            })
        })

    return {
        btnShow
    }
}

const funcJS = lockedProfile()
