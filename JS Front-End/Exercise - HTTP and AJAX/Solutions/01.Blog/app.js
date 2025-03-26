function attachEvents() {
    const POSTS_URL = 'http://localhost:3030/jsonstore/blog/posts';
    const COMMENTS_URL = 'http://localhost:3030/jsonstore/blog/comments';

    const postSelectEl = document.getElementById('posts');
    const postTitleEl = document.getElementById('post-title');
    const postBodyEl = document.getElementById('post-body');
    const postCommentsEl = document.getElementById('post-comments');

    const loadPostsBtn = document.getElementById('btnLoadPosts');
    const viewPostsBtn = document.getElementById('btnViewPost');

    let postsData = {};

    loadPostsBtn.addEventListener('click', loadPostsHandler);
    viewPostsBtn.addEventListener('click', viewPostsHandler);

    function createOptions(posts) {
        return Object.keys(posts).map(key => {
            const optionEl = document.createElement('option');
            optionEl.value = key;
            optionEl.text = posts[key].title;
            return optionEl;
        });
    }

    async function loadPostsHandler() {
        postSelectEl.innerHTML = '';

        try {
            const response = await fetch(POSTS_URL);
            if (!response.ok) {
                throw new Error('Failed to fetch posts.');
            }

            const posts = await response.json();
            postsData = posts;
            
            const options = createOptions(posts);
            postSelectEl.append(...options);
        } catch (error) {
            alert(error.message);
        }
    }

    function createCommentsText(comments) {
        return comments.map(comment => {
            const commentTextEl = document.createElement('li');
            commentTextEl.textContent = comment.text;

            return commentTextEl;
        })
    }

    async function viewPostsHandler() {
        const selectedPostId = postSelectEl.value;

        if (!selectedPostId) {
            return;
        }

        const selectedPost = postsData[selectedPostId];

        if (!selectedPost) {
            return;
        }

        postTitleEl.textContent = selectedPost.title;
        postBodyEl.textContent = selectedPost.body;
        postCommentsEl.innerHTML = '';

        try {
            const response = await fetch(COMMENTS_URL);

            if (!response.ok) {
                throw new Error('Failed to fetch comments.');
            }

            const comments = await response.json();
            const filteredComments = Object.values(comments)
                .filter(comment => comment.postId === selectedPostId);

            const commentsTexts = createCommentsText(filteredComments);
            postCommentsEl.append(...commentsTexts);
        } catch (error) {
            alert(error.message);
        }
    }
}

attachEvents();
