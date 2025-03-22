function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   
   const rowsElements = document.querySelectorAll('.container tbody tr');
   const searchFieldElement = document.getElementById('searchField');

   function getMatchingElements(input) {
      return [...rowsElements].filter(rowElement =>
         rowElement.textContent.toLocaleLowerCase().includes(input.toLowerCase())
      );
   }

   function clearPreviousState() {
      [...rowsElements].forEach(rowElement =>
         rowElement.classList.remove('select')
      );
   }

   function onClick() {
      clearPreviousState();

      const matchRows = getMatchingElements(searchFieldElement.value);

      matchRows.forEach(row => 
         row.classList.add('select')
      );

      searchFieldElement.value = '';
   }
}
