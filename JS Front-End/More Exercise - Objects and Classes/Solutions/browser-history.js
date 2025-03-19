function browseTheWeb(browser, commands) {
    for (const command of commands) {
        if (command === 'Clear History and Cache') {
            browser['Open Tabs'] = [];
            browser['Recently Closed'] = [];
            browser['Browser Logs'] = [];
        }

        const [action, site] = command.split(' ');

        if (action === 'Open') {
            browser['Open Tabs'].push(site);
            browser['Browser Logs'].push(`Open ${site}`);
        } else if (action === 'Close') {
            const tabIndex = browser['Open Tabs'].indexOf(site);

            if (tabIndex !== -1) {
                browser['Open Tabs'].splice(tabIndex, 1); //Close the tab at tabIndex
                browser['Recently Closed'].push(site);
                browser['Browser Logs'].push(`Close ${site}`);
            }
        } 
    }

    console.log(browser['Browser Name']);
    console.log(`Open Tabs: ${browser['Open Tabs'].join(', ')}`);
    console.log(`Recently Closed: ${browser['Recently Closed'].join(', ')}`);
    console.log(`Browser Logs: ${browser['Browser Logs'].join(', ')}`);
}

browseTheWeb({"Browser Name":"Mozilla Firefox", "Open Tabs":["YouTube"], "Recently Closed":["Gmail", "Dropbox"], "Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]},
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]);
