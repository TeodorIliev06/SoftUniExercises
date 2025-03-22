function solve() {
   const resultElement = document.querySelector('textarea[disabled]');
   const checkoutButton = document.querySelector('button.checkout');
   const productCatalogueElement = document.querySelector('.shopping-cart');

   let products = [];

   // Using event delegation
   productCatalogueElement.addEventListener('click', (e) => {
      // Tagname is always uppercase
      if (e.target.tagName !== 'BUTTON' ||
          e.target.textContent.trim() !== 'Add') {
         return;
      }

      // Prefered closest()
      const productElement = e.target.closest('.product');
      const name = productElement.querySelector('.product-title').textContent;
      const price = Number(productElement.querySelector('.product-line-price').textContent);

      resultElement.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;

      // Save products in cart for checkout
      products.push({
         name,
         price,
      });
   });
   
   checkoutButton.addEventListener('click', (e) => {
      const totalPrice = products.reduce((price, product) => price + product.price, 0);
      const productList = [...new Set(products.map(product => product.name))];

      resultElement.value += `You bought ${productList.join(', ')} for ${totalPrice.toFixed(2)}.`;

      //Disable all buttons after checkout
      document.querySelectorAll('button.add-product, button.checkout')
         .forEach(btn => btn.setAttribute('disabled', 'disabled'));
   });
}
