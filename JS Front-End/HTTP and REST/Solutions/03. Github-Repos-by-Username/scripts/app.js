function loadRepos() {
	const inputEl = document.getElementById('username');
	const ulEl = document.getElementById('repos');

	const username = inputEl.value.trim();
	const baseUrl = `https://api.github.com/users/${username}/repos`;

	ulEl.innerHTML = '';

	fetch(baseUrl)
         .then(response => {
            if (!response.ok) {
               throw Error('Not Found');
            }

            return response.json();
         })
         .then(repos => {
			repos.forEach(repo => {
				const linkEl = document.createElement('a');
				const liEl = document.createElement('li');
				linkEl.setAttribute('href', `${repo.html_url}`);
				linkEl.setAttribute('target', '_blank');
				linkEl.textContent = repo.full_name;

				liEl.append(linkEl);
				ulEl.append(liEl);
			});
		 })
         .catch(err => {
			const errorEl = document.createElement('li');
			errorEl.textContent = err.message;
			
			ulEl.append(errorEl);
		 });
}
