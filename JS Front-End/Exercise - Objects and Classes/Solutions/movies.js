function printMovies(commands) {
    const movies = [];

    for (const command of commands) {
        if (command.startsWith('addMovie')) {
            const movieName = command.replace('addMovie ', '');
            movies.push({name: movieName});
        } else if (command.includes('directedBy')){
            const [movieName, director] = command.split(' directedBy ');
            const movie = movies.find(m => m.name === movieName);

            if (movie) {
                movie.director = director;
            }
        } else if (command.includes('onDate')){
            const [movieName, date] = command.split(' onDate ');
            const movie = movies.find(m => m.name === movieName);

            if (movie) {
                movie.date = date;
            }
        }
    }

    const completeMovies = movies.filter(m => m.name && m.director && m.date);

    completeMovies.forEach(movie => {
        console.log(JSON.stringify(movie));
    }); 
}
