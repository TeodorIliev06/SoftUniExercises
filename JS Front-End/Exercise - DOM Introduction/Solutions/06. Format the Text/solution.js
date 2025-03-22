function solve() {
  const textElement = document.getElementById('input');
  const outputElement = document.getElementById('output');

  // Remove empty sentences and extra spaces around each sentence
  const textInSentences = textElement.value
    .split('.')
    .map(sentence => sentence.trim())
    .filter(sentence => sentence.length > 0);

  for (let i = 0; i < textInSentences.length; i += 3) {
    const paragraphSentences = textInSentences.slice(i, i + 3)
      .join('. ') + '.';

    const paragraph = document.createElement('p');
    paragraph.textContent = paragraphSentences;

    outputElement.appendChild(paragraph);
  }
}
