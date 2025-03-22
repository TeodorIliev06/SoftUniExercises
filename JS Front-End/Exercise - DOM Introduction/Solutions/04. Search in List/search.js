function search() {
   const townsElements = document.querySelectorAll('#towns li');
   const searchText = document.querySelector('#searchText').value;
   const resultElement = document.getElementById('result');

   //Reset styling
   Array.from(townsElements)
      .forEach(town => {
         town.style.textDecoration = 'inherit';
         town.style.fontWeight = 'inherit';
      });

   searchText.textContent = '';
   resultElement.textContent = '';
   
   //Apply styling
   const filteredTowns = Array.from(townsElements)
      .filter(town => town.textContent.includes(searchText) && searchText);
   const matches = filteredTowns.length;

   filteredTowns.forEach(town => {
      town.style.textDecoration = 'underline';
      town.style.fontWeight = 'bold';
   });

   resultElement.textContent = `${matches} matches found`;
}
