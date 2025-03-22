function solve(text, namingConvention) {
  const CAMEL_CASE = 'Camel Case';
  const PASCAL_CASE = 'Pascal Case';

  const textElement = document.querySelector('#text');
  const namingConventionElement = document.querySelector('#naming-convention');
  const resultElement = document.getElementById('result');

  const words = textElement.value.toLowerCase().split(' ');

  let output = '';

  if (namingConventionElement.value === CAMEL_CASE) {
    output = words
      .map((word, index) =>
        index === 0 ? word : word[0].toUpperCase() + word.slice(1))
      .join('');
  } else if (namingConventionElement.value === PASCAL_CASE) {
    output = words
      .map(word => word[0].toUpperCase() + word.slice(1))
      .join('');
  } else {
    output = 'Error!';
  }

  resultElement.textContent = output;
}
