function attachEvents() {
    const GENERAL_ERROR_MESSAGE = 'Error';
    const BASE_URL = 'http://localhost:3030/jsonstore/phonebook';

    const phonebook = document.getElementById('phonebook');
    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');

    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    loadBtn.addEventListener('click', loadContacts);
    createBtn.addEventListener('click', createContact);

    function handleResponseError(response, message) {
        if (!response.ok) {
            throw new Error(message);
        }
    }

    function createContactElement(person, phone, id) {
        const contact = document.createElement('li');
        contact.textContent = `${person}: ${phone}`;
        contact.id = id;

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', () => deleteContact(id, contact));

        contact.appendChild(deleteBtn);
        return contact;
    }

    async function loadContacts() {
        phonebook.innerHTML = '';
    
        try {
            const response = await fetch(BASE_URL);

            handleResponseError(response, GENERAL_ERROR_MESSAGE);

            const data = await response.json();
    
            const contactElements = Object.values(data).map(entry => {
                const { person, phone, _id } = entry;
                return createContactElement(person, phone, _id);
            });
    
            phonebook.append(...contactElements);
        } catch (error) {
            //TODO: Alert
        }
    }    

    async function createContact() {
        const person = personInput.value.trim();
        const phone = phoneInput.value.trim();

        if (!person || !phone) {
            //TODO: Alert - both fields required
            return;
        }

        const newContact = { person, phone };

        try {
            const response = await fetch(BASE_URL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newContact),
            });

            handleResponseError(response, GENERAL_ERROR_MESSAGE);

            personInput.value = '';
            phoneInput.value = '';

            loadContacts();
        } catch (error) {
            //TODO: Alert
        }
    }

    async function deleteContact(id, contactElement) {
        try {
            const response = await fetch(`${BASE_URL}/${id}`, {
                method: 'DELETE',
            });

            handleResponseError(response, GENERAL_ERROR_MESSAGE);

            contactElement.remove();
        } catch (error) {
            //TODO: Alert
        }
    }
}

attachEvents();
