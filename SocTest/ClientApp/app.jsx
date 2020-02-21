import React from 'react';
import ReactDOM from 'react-dom';
var redux = require("redux");
import { Provider } from 'react-redux';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import axios from 'axios';
import axiosMiddleware from 'redux-axios-middleware';
import reducer from './reducer.jsx';
import AuthorizationForm from './authorization.jsx';
import Questions from './questions.jsx';
import Result from './result.jsx';

const client = axios.create({
    baseURL: '/api',
    responseType: 'json',
    withCredentials: true,
    method: 'post'
});

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = redux.createStore(reducer,
    {
        user: {},
        user_authorized: false,
        test_result: {},
        prev_results: [],
        get_result_success: false,
        authorization_form: {
            visibility: 'visible',
            firstname: '',
            lastname: '',
            isLoading: false,
            isValid: 'success'
        },
        questions: {
            questions: [],
            results: [],
            currentQuestion: 0,
            selectedAnswer: 0,
            isLoading: false,
            soc_type: '',
            about_soc_type: '',
            radio1checked: false,
            radio2checked: false
        }
    },
    composeEnhancers(redux.applyMiddleware(axiosMiddleware(client)))
);

ReactDOM.render(
    <Provider store={store}>
        <Router>
            <Switch>
                <Route exact path="/" component={AuthorizationForm} />
                <Route path="/questions" component={Questions} />
                <Route path="/result" component={Result} />
            </Switch>
        </Router>
    </Provider>,
    document.getElementById("root")
);