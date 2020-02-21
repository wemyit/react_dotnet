var reducer = function (state, action) {
    switch (action.type) {
        case 'LOGIN':
            if (state.authorization_form.firstname.length <= 2 || state.authorization_form.lastname.length <= 2)
                return state;
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    isLoading: true
                }
            };
        case 'LOGIN_SUCCESS':
            return {
                ...state,
                user: action.payload.data,
                user_authorized: true,
                authorization_form: {
                    ...state.authorization_form,
                    isLoading: false
                }
            };
        case 'LOGIN_FAIL':
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    isLoading: false
                }
            };
        case 'REGISTRATION':
            if (state.authorization_form.firstname.length <= 2 || state.authorization_form.lastname.length <= 2)
                return state;
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    isLoading: true
                }
            };
        case 'REGISTRATION_SUCCESS':
            return {
                ...state,
                user: action.payload.data,
                user_authorized: true,
                authorization_form: {
                    ...state.authorization_form,
                    isLoading: false
                }
            };
        case 'LOGIN_VALIDATION':
            if (state.authorization_form.firstname.length > 1 && state.authorization_form.lastname.length > 1) {
                return {
                    ...state,
                    authorization_form: {
                        ...state.authorization_form,
                        isValid: 'success'
                    }
                }
            }
            else if (state.authorization_form.firstname.length > 0 || state.authorization_form.lastname.length < 2)
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    isValid: 'error'
                }
            }
        case 'FIRSTNAME_CHANGED':
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    firstname: action.firstname
                }
            };
        case 'LASTNAME_CHANGED':
            return {
                ...state,
                authorization_form: {
                    ...state.authorization_form,
                    lastname: action.lastname
                }
            };
        case 'LOAD_QUESTION_SUCCESS':
            return {
                ...state,
                questions: {
                    ...state.questions,
                    questions: action.payload.data
                }
            }
        case 'ANSWER_ONE_SELECTED':
            return {
                ...state,
                questions:{
                    ...state.questions,
                    radio1checked: true,
                    radio2checked: false,
                    selectedAnswer: 1
                }
            }
        case 'ANSWER_TWO_SELECTED':
            return {
                ...state,
                questions: {
                    ...state.questions,
                    radio1checked: false,
                    radio2checked: true,
                    selectedAnswer: 2
                }
            }
        case 'GET_RESULT_SUCCESS':
            return {
                ...state,
                get_result_success: true,
                test_result: action.payload.data.testResult
            }
        case 'GET_PREV_RESULTS_SUCCESS':
            return {
                ...state,
                prev_results: action.payload.data
            }
        case 'NEXT_QUESTION':
            if (state.questions.selectedAnswer === 0) {
                return state;
            }
            let temp_result = state.questions.results;
            temp_result.push(action.answer);
            if (state.questions.currentQuestion === state.questions.questions.length - 1) {
                return {
                    ...state,
                    questions: {
                        ...state.questions,
                        result: temp_result
                    }
                }
            }
            return {
                ...state,
                questions: {
                    ...state.questions,
                    result: temp_result,
                    selectedAnswer: 0,
                    currentQuestion: state.questions.currentQuestion+1,
                    radio1checked: false,
                    radio2checked: false
                }
            }
    }
    return state;
}

module.exports = reducer;