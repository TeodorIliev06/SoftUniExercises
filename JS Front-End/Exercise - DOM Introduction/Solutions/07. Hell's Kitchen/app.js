function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   const inputTextArea = document.querySelector('#input textarea');
   const bestRestaurantElement = document.querySelector('#bestRestaurant p');
   const workersElement = document.querySelector('#workers p');

   function onClick() {
      const restaurants = JSON.parse(inputTextArea.value)
         .reduce((acc, restaurantData) => {
            const [restaurantName, workersData] = restaurantData.split(' - ');
            
            const workers = workersData.split(', ').map(workerData => {
               const [name, salary] = workerData.split(' ');
               return { name, salary: Number(salary) };
            });

            // If the restaurant already exists, add to its worker list
            if (!acc[restaurantName]) {
               acc[restaurantName] = { workers: [] };
            }

            // Add new workers to the existing restaurant's workers array
            acc[restaurantName].workers.push(...workers);

            return acc;
         }, {});
      
      // Calculate average salary for a restaurant's workers
      function getAvgSalary(restaurantData) {
         return restaurantData.workers.reduce((acc, curr) => acc + curr.salary, 0) / restaurantData.workers.length;
      }

      const [bestRestaurantKey] = Object.keys(restaurants)
         .sort((a, b) => getAvgSalary(restaurants[b]) - getAvgSalary(restaurants[a]));

      const bestRestaurant = restaurants[bestRestaurantKey];
      const bestAvgSalary = getAvgSalary(bestRestaurant);
      const bestWorkers = bestRestaurant.workers.slice().sort((a, b) => b.salary - a.salary);
      const bestSalary = bestWorkers[0].salary;

      bestRestaurantElement.textContent = `Name: ${bestRestaurantKey} Average Salary: ${bestAvgSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
      workersElement.textContent = bestWorkers.map(worker => `Name: ${worker.name} With Salary: ${worker.salary}`).join(' ');
   }
}
