"use strict";
let searchResultTemplate = document.querySelector('#search-result');
import {ObjectDebounce} from './wasync.js';

let loading = false;

let debounce = new ObjectDebounce().func({
    validate(txt) {
        loading = true;
        toggleLoading();
        return txt;
    },
    prepare() {
        clearSearchResults();
        loading = true;
        toggleLoading();
    },
    cleanup() {
        loading = false;
        toggleLoading();
    },
    run(txt) {
       return getSearchResults(txt); 
    },
    success(results) {
        if (results !== null || results !== undefined) {
            renderSearchResults(results);
        }
    },
    failure(error) {
        loading = false;
        toggleLoading();
        clearSearchResults();
        console.log(error);
    },
});

function clearSearchResults() {
    document.querySelectorAll('.search-result').forEach(e => e.remove());
}

function toggleLoading() {
    let result = loading;
    do {
        result = document.querySelector('#search-box').parentElement.classList.toggle('is-loading');
    }
    while (loading !== result);
}

async function renderSearchResults(results) {
    let searchboxGrandParentNode = document.querySelector('#search-box').parentNode.parentNode;

    let bottom = -10;
    for (const result of results.data) { 
        bottom -= 100;
        let cloneSearchResultTemplate = document.importNode(searchResultTemplate.content, true);
        let cloneSearchResult = cloneSearchResultTemplate.querySelector('.search-result');
        cloneSearchResult.style.bottom = `${bottom}%`;
        let cloneSearchResultLink = cloneSearchResult.querySelector('a');
        cloneSearchResultLink.outerHTML = `<a class="card-header-title is-clipped" href="#">${result.entries[0].phoneNumber} - ${result.lastName}, ${result.firstName}</a>`;
        searchboxGrandParentNode.appendChild(cloneSearchResult);
    } 
}

 

 

async function getSearchResults(searchTerm) {
    if (searchTerm === undefined || searchTerm === null || searchTerm === '') {
        loading = false;
        toggleLoading();
        clearSearchResults();
        return;
    }
      
    let searchUrl = `/api/Search/phonebook/${searchTerm}`;
     
    let res = await fetch(searchUrl);
    if (!res.ok) {
        return;
    }
    let data = await res.json();
    if (data !== null || data !== undefined) {
        return data;
    }
}

(async function () {
    document.getElementById('search-box').addEventListener('input', async function (evt) {
        if (this.value === undefined || this.value === null || this.value === '') {
            loading = false;
            toggleLoading();
            clearSearchResults();
            return;
        }
        await debounce(this.value);
    });
})();