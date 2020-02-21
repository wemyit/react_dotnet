import React from 'react';
import { connect } from 'react-redux';
import { Grid, Col, Row, FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';
import { withRouter } from 'react-router-dom';
import axios from 'axios';

var actions = require("./actions.jsx");

class AuthorizationForm extends React.Component {

    componentWillUpdate(nextProps, nextState) {
        if (nextProps.user_authorized) {
            this.props.loadQuestions();
            this.props.history.push('/questions');
        }
    }

    loginHandler() {
        if (this.props.state.isValid === 'success') {
            this.props.login({
                FirstName: this.props.state.firstname,
                LastName: this.props.state.lastname
            });
        }
    }

    regHandler() {
        if (this.props.state.isValid === 'success') {
            this.props.registration({
                FirstName: this.props.state.firstname,
                LastName: this.props.state.lastname
            });
        }
    }

    render() {
        return <Grid>
            <Row>
                <Col md={6} mdOffset={3}>
                    <form>
                        <FormGroup controlId="authForm" validationState={this.props.state.isValid}>
                            <ControlLabel>Введите имя и фамилию</ControlLabel>
                            <FormControl
                                type="text"
                                value={this.props.state.firstname}
                                placeholder="Имя"
                                onChange={(e) => { this.props.firstnameChanged(e); this.props.validation(); }}
                                style={{ margin: 5 }}
                            />
                            <FormControl
                                type="text"
                                value={this.props.state.lastname}
                                placeholder="Фамилия"
                                onChange={(e) => { this.props.lastnameChanged(e); this.props.validation(); }}
                                style={{ margin: 5 }}
                            />
                        </FormGroup>
                        <Button bsStyle="primary" onClick={() => { this.loginHandler() }} disabled={this.props.state.isLoading} style={{ margin: 5 }}>{this.props.state.isLoading ? "Loading..." : "Login"}</Button>
                        <Button bsStyle="primary" onClick={() => { this.regHandler() }} disabled={this.props.state.isLoading} style={{ margin: 5 }}>{this.props.state.isLoading ? "Loading..." : "Registration"}</Button>
                    </form>
                </Col>
            </Row>
        </Grid>
    }
}

function mapStateToProps(state) {
    return {
        state: state.authorization_form,
        user_authorized: state.user_authorized
    };
}

function mapDispatchToProps(dispatch) {
    return {
        firstnameChanged: (e) => {
            dispatch(actions.firstnameChanged(e.target.value))
        },
        lastnameChanged: (e) => {
            dispatch(actions.lastnameChanged(e.target.value))
        },
        validation: () => {
            dispatch(actions.authRegValidation())
        },
        login: (data) => {
            dispatch(actions.login(data))
        },
        loadQuestions: () => {
            dispatch(actions.loadQuestions())
        },
        registration: (data) => {
            dispatch(actions.registration(data))
        }
    }
}

module.exports = connect(mapStateToProps, mapDispatchToProps)(withRouter(AuthorizationForm));