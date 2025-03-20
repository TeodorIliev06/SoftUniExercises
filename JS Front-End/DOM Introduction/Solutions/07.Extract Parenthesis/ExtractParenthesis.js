function extract(content) {
    const contentElement = document.getElementById('content');

    const pattern = /\(([^()]+)\)/g;
    const matches = contentElement.textContent.matchAll(pattern);

    return Array.from(matches)
        .map(match => match[1])
        .join('; ');
}
