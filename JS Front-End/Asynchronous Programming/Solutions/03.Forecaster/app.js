function attachEvents() {
    const DEGREE_SYMBOL = '\u00B0';
    const WEATHER_SYMBOLS = {
        'Sunny': '\u2600',         
        'Partly sunny': '\u26C5',  
        'Overcast': '\u2601',      
        'Rain': '\u2614'           
    };
    const GENERAL_ERROR_MESSAGE = 'Error';

    const locationEl = document.getElementById('location');
    const getWeatherBtn = document.getElementById('submit');
    const forecastEl = document.getElementById('forecast');
    const currentEl = document.getElementById('current');
    const upcomingEl = document.getElementById('upcoming');

    const locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';

    getWeatherBtn.addEventListener('click', fetchForecasts);

    async function fetchForecasts() {
        const locationName = locationEl.value.trim();
        
        if (!locationName) {
            alert("Please enter a location.");
            return;
        }

        forecastEl.style.display = 'none';
        currentEl.innerHTML = '<div class="label">Current conditions</div>';
        upcomingEl.innerHTML = '<div class="label">Three-day forecast</div>';

        try {
            const locationsResponse = await fetch(locationsUrl);
            checkResponse(locationsResponse);

            const locations = await locationsResponse.json();
            const location = locations.find(l => l.name.toLowerCase() === locationName.toLowerCase());

            if (!location) {
                throw new Error(GENERAL_ERROR_MESSAGE);
            } 

            const currentWeatherUrl = `http://localhost:3030/jsonstore/forecaster/today/${location.code}`;
            const upcomingWeatherUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`;

            const [currentWeatherResponse, upcomingWeatherResponse] = await Promise.all([
                fetch(currentWeatherUrl),
                fetch(upcomingWeatherUrl)
            ]);

            checkResponse(currentWeatherResponse);
            checkResponse(upcomingWeatherResponse);

            const currentWeatherData = await currentWeatherResponse.json();
            const upcomingWeatherData = await upcomingWeatherResponse.json();

            displayCurrentWeather(currentWeatherData);
            displayUpcomingWeather(upcomingWeatherData);

            forecastEl.style.display = 'block';
        } catch (error) {
            forecastEl.style.display = 'block';
            currentEl.textContent = GENERAL_ERROR_MESSAGE;
            upcomingEl.innerHTML = '';
        }
    }

    function checkResponse(response) {
        if (!response.ok) {
            throw new Error(GENERAL_ERROR_MESSAGE);
        }
    }

    function createWeatherElement(tag, className, content = '') {
        const element = document.createElement(tag);
        if (className) element.classList.add(className);
        if (content) element.innerHTML = content;
        return element;
    }

    function createSymbolElement(condition) {
        const symbolEl = createWeatherElement('span', 'symbol', WEATHER_SYMBOLS[condition] || '');
        return symbolEl;
    }

    function displayCurrentWeather(data) {
        const { name, forecast } = data;
        const { low, high, condition } = forecast;

        const weatherDiv = document.createElement('div');
        weatherDiv.classList.add('forecasts');

        const symbolEl = createSymbolElement(condition);
        const conditionEl = createWeatherElement('span', 'condition');

        const locationEl = createWeatherElement('span', 'forecast-data', name);
        const tempEl = createWeatherElement('span', 'forecast-data', `${low}${DEGREE_SYMBOL}/${high}${DEGREE_SYMBOL}`);
        const conditionTextEl = createWeatherElement('span', 'forecast-data', condition);

        conditionEl.appendChild(locationEl);
        conditionEl.appendChild(tempEl);
        conditionEl.appendChild(conditionTextEl);

        weatherDiv.appendChild(symbolEl);
        weatherDiv.appendChild(conditionEl);

        currentEl.appendChild(weatherDiv);
    }

    function displayUpcomingWeather(data) {
        const forecastInfoDiv = document.createElement('div');
        forecastInfoDiv.classList.add('forecast-info');

        data.forecast.forEach(day => {
            const { low, high, condition } = day;

            const upcomingSpan = document.createElement('span');
            upcomingSpan.classList.add('upcoming');

            const symbolEl = createSymbolElement(condition);
            const tempEl = createWeatherElement('span', 'forecast-data', `${low}${DEGREE_SYMBOL}/${high}${DEGREE_SYMBOL}`);
            const conditionTextEl = createWeatherElement('span', 'forecast-data', condition);

            upcomingSpan.appendChild(symbolEl);
            upcomingSpan.appendChild(tempEl);
            upcomingSpan.appendChild(conditionTextEl);

            forecastInfoDiv.appendChild(upcomingSpan);
        });

        upcomingEl.appendChild(forecastInfoDiv);
    }
}

attachEvents();
