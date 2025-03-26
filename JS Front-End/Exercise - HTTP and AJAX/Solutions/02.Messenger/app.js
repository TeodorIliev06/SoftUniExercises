function attachEvents() {
    const REQUESTS_URL = 'http://localhost:3030/jsonstore/messenger';

    const textareaEl = document.getElementById('messages');
    const authorEl = document.querySelector('input[name=author]');
    const contentEl = document.querySelector('input[name=content]');

    const sendBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    sendBtn.addEventListener('click', sendDataHandler);
    refreshBtn.addEventListener('click', refreshHandler);

    async function sendDataHandler() {
        const author = authorEl.value;
        const content = contentEl.value;

        if (!author || !content) {
            //TODO: Alert
            return;
        }

        const newMessage = { author, content };

        try {
            const response = await fetch(REQUESTS_URL, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newMessage),
            });

            if (!response.ok) {
                throw new Error('Error');
            }

            authorEl.value = '';
            contentEl.value = '';
        } catch (error) {
            //TODO: Alert
        }
    }

    async function refreshHandler() {
        const response = await fetch(REQUESTS_URL);

        if (!response.ok) {
            throw new Error('Error');
        }

        const messages = await response.json();
        const formattedMessages = Object.values(messages)
            .map(message => `${message.author}: ${message.content}`)
            .join('\n');

        textareaEl.value = formattedMessages;
    }
}

attachEvents();
