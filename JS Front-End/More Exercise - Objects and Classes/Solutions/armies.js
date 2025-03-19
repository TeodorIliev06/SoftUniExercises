function getArmyInfo(input) {
    const leaders = new Map();

    for (const entry of input) {
        if (entry.includes('arrives')) {
            const leader = entry.split(' ')[0];

            if (!leaders.has(leader)) {
                leaders.set(leader, { totalArmy: 0, armies: {} });
            }
        } else if (entry.includes(':')) {
            const [leader, data] = entry.split(': ');
            const [armyName, armyCount] = data.split(', ');
            const count = Number(armyCount);

            if (leaders.has(leader)) {
                const leaderInfo = leaders.get(leader);

                if (!leaderInfo.armies[armyName]) {
                    leaderInfo.armies[armyName] = 0;
                }

                leaderInfo.armies[armyName] += count;
                leaderInfo.totalArmy += count;
            }
        } else if (entry.includes('+')) {
            const [armyName, armyCount] = entry.split(' + ');
            const count = Number(armyCount);

            for (const [leader, data] of leaders.entries()) {
                if (data.armies[armyName]) {
                    data.armies[armyName] += count;
                    data.totalArmy += count;
                }
            }    
        } else if (entry.includes('defeated')) {
            const leader = entry.split(' ')[0];

            if (leaders.has(leader)) {
                leaders.delete(leader);
            }
        }
    }

    //Sort by leaders' army count desc
    const sortedLeaders = [...leaders.entries()]
        .sort((a, b) => b[1].totalArmy - a[1].totalArmy);

    for (const [leader, data] of sortedLeaders) {
        console.log(`${leader}: ${data.totalArmy}`);

        const sortedArmies = Object.entries(data.armies)
            .sort((a, b) => b[1] - a[1]);

        for (const [armyName, armyCount] of sortedArmies) {
            console.log(`>>> ${armyName} - ${armyCount}`);
        }
    }
}

getArmyInfo(['Rick Burr arrives', 'Fergus: Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000', 'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205']);
