function loadRepos() {
   const baseUrl = 'https://api.github.com/users/testnakov/repos';
   const resultEl = document.getElementById('res');

   fetch(baseUrl)
         .then(response => {
            if (!response.ok) {
               throw Error('Something went wrong');
            }

            return response.text();
         })
         .then(result => resultEl.textContent = result)
         .catch(err => console.log(err.message));
}
