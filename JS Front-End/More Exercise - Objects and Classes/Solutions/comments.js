function getComments(input) {
    const blog = new Map();
    const users = new Set();
    const articles = new Set();

    for (const entry of input) {
        if (entry.startsWith('user ')) {
            const user = entry.split(' ')[1];
            users.add(user);
        } else if (entry.startsWith('article ')) {
            const article = entry.split(' ')[1];
            articles.add(article);

            if (!blog.has(article)) {
                blog.set(article, []);
            }
        } else {
            const [userArticlePart, commentInfo] = entry.split(': ');
            const [username, articleName] = userArticlePart.split(' posts on ');

            if (users.has(username) &&
                articles.has(articleName)) {
                    const [commentTitle, commentContent] = commentInfo.split(', ');

                    blog.get(articleName).push({
                        username,
                        title: commentTitle,
                        content: commentContent
                    });
            }
        }
    }

    //... (spread operator), used to make an array of the Map
    const sortedArticles = [...blog.entries()]
        .sort((a, b) => b[1].length - a[1].length);

    for (const [article, comments] of sortedArticles) {
        console.log(`Comments on ${article}`);

        comments.sort((a, b) => a.username.localeCompare(b.username));

        for (const { username, title, content } of comments) {
            console.log(`--- From user ${username}: ${title} - ${content}`);
        }
    }
}

getComments(['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much']);
