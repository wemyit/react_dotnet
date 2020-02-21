export const login = function (data) {
    return {
        type: 'LOGIN',
        payload: {
            request: {
                url: '/user/auth',
                data: data
            }
        }
    }
}
export const registration = function (data) {
    return {
        type: 'REGISTRATION',
        payload: {
            request: {
                url: '/user/register',
                data: data
            }
        }
    }
}
export const authRegValidation = function () {
    return {
        type: 'LOGIN_VALIDATION'
    }
}
export const firstnameChanged = function (firstname) {
    return {
        type: 'FIRSTNAME_CHANGED',
        firstname: firstname
    }
}
export const lastnameChanged = function (lastname) {
    return {
        type: 'LASTNAME_CHANGED',
        lastname: lastname
    }
}
export const loadQuestions = function (){
    return {
        type: 'LOAD_QUESTION',
        payload: {
            request: {
                url: '/question/getquest'
            }
        }
    }
}
export const answerOneSelected = function () {
    return {
        type: 'ANSWER_ONE_SELECTED'
    }
}
export const answerTwoSelected = function () {
    return {
        type: 'ANSWER_TWO_SELECTED'
    }
}
export const nextQuestion = function (answer) {
    return {
        type: 'NEXT_QUESTION',
        answer
    }
}
export const getResult = function (data) {
    return {
        type: 'GET_RESULT',
        payload: {
            request: {
                url: 'question/checkanswer',
                data: data
            }
        }
    }
}
export const getPrevResults = function (data) {
    return {
        type: 'GET_PREV_RESULTS',
        payload: {
            request: {
                url: '/question/getusersresults',
                data: data
            }
        }
    }
}
