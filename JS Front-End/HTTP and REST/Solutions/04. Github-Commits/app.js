function loadCommits() {
    const inputUsernameEl = document.getElementById('username');
    const inputRepoEl = document.getElementById('repo');
	const ulEl = document.getElementById('commits');

	const username = inputUsernameEl.value.trim();
	const repository = inputRepoEl.value.trim();
	const baseUrl = `https://api.github.com/repos/${username}/${repository}/commits`;

	ulEl.innerHTML = '';

	fetch(baseUrl)
         .then(response => {
            if (!response.ok) {
               throw Error(`Error: ${response.status} (Not Found)`);
            }

            return response.json();
         })
         .then(results => {
			results.forEach(result => {
                console.log(result);
                
				const liEl = document.createElement('li');
                const authorName = result.commit.author.name;
                const message = result.commit.message;

				liEl.textContent = `${authorName}: ${message}`;
                ulEl.append(liEl);
			});
            
		 })
         .catch(err => {
			const errorEl = document.createElement('li');
			errorEl.textContent = err.message;
			
			ulEl.append(errorEl);
		 });
}
