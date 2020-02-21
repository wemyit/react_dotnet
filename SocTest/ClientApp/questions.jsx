import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { Grid, Col, Row, FormGroup, ControlLabel, FormControl, Button, Radio, ButtonGroup, RadioGroup } from 'react-bootstrap';
import axios from 'axios';

var actions = require("./actions.jsx");

class Questions extends React.Component {

    componentWillMount() {
        if (!this.props.user_authorized) {
            this.props.history.push('/');
        }
    }

    componentWillUpdate(nextProps, nextState) {
        if (nextProps.get_result_success) {
            this.props.history.push('/result');
        }
    }

    nextHandler() {
        this.props.nextQuestion({
            NumOfAnswer: this.props.state.selectedAnswer,
            QuestionId: this.props.state.questions[this.props.state.currentQuestion].id
        });
        if (this.props.state.results.length === this.props.state.questions.length) {
            this.props.getResult(this.props.state.results);
        }

    }

    keyPressHandler(e){
        if (e.key == 'Enter') {
            this.nextHandler();
        }
        if (e.key == '1') {
            this.props.answer1selected();
        }
        if (e.key == '2') {
            this.props.answer2selected();
        }
    }

    render() {
        return <Grid>
            <Row>
                <Col md={6} mdOffset={3}>
                    <h3>Добрый день, {this.props.user.firstName}!</h3>
                    <form onKeyPress={(e) => this.keyPressHandler(e)}>
                        <ControlLabel>Выберите утверждение, с которым вы наиболее согласны</ControlLabel>
                        <FormGroup>
                            <Radio name="answerradio" checked={this.props.state.radio1checked} onChange={() => { this.props.answer1selected() }}>{this.props.state.questions.length > 0 ? this.props.state.questions[this.props.state.currentQuestion].answer1 : ""}</Radio>
                            <Radio name="answerradio" checked={this.props.state.radio2checked} onChange={() => { this.props.answer2selected() }}>{this.props.state.questions.length > 0 ? this.props.state.questions[this.props.state.currentQuestion].answer2 : ""}</Radio>
                        </FormGroup>
                        <p>Вопрос {this.props.state.currentQuestion + 1} из {this.props.state.questions.length}</p>
                        <Button onClick={() => { this.nextHandler() }}>Далее</Button>
                    </form>
                </Col>
            </Row>
        </Grid>
    }
}

function mapStateToProps(state) {
    return {
        user: state.user,
        user_authorized: state.user_authorized,
        get_result_success: state.get_result_success,
        state: state.questions
    };
}

function mapDispatchToProps(dispatch) {
    return {
        answer1selected: () => {
            dispatch(actions.answerOneSelected());
        },
        answer2selected: () => {
            dispatch(actions.answerTwoSelected());
        },
        nextQuestion: (answer) => {
            dispatch(actions.nextQuestion(answer));
        },
        getResult: (data) => {
            dispatch(actions.getResult(data))
        }
    };
}

module.exports = connect(mapStateToProps, mapDispatchToProps)(withRouter(Questions));