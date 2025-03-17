function printSongs(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const songsCount = Number(input[0]);
    let songs = [];
    
    for (let i = 1; i <= songsCount; i++) {
        const [typeList, name, time] = input[i].split('_');
        const song = new Song(typeList, name, time);
        songs.push(song);
    }

    const filterType = input[input.length - 1];

    if (filterType !== 'all') {
        songs = songs.filter(song => song.typeList === filterType);
    }
        
    songs.forEach(song => console.log(song.name));
}
