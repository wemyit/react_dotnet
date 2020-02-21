import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { Grid, Col, Row, FormGroup, ControlLabel, FormControl, Button, Radio, ButtonGroup, RadioGroup } from 'react-bootstrap';
var actions = require("./actions.jsx");

class Result extends React.Component {

    componentWillMount() {
        if (!this.props.user_authorized) {
            this.props.history.push('/');
        }
        if (!this.props.get_result_success) {
            this.props.history.push('/questions');
        }
        this.props.getPrevResults();
    }

    render() {
        return <Grid>
            <Row>
                <Col md={6} mdOffset={3}>
                    <h3>Ваш соционический тип:</h3>
                    <h2>{this.props.state.socType}</h2>
                    <p>{this.props.state.aboutType}</p>
                    <Button onClick={() => { this.props.history.push('/'); }}>Пройти заново</Button>
                </Col>
            </Row>
            <Row>
                <Col md={6} mdOffset={3}>
                    <p style={{ marginTop:20 }}><b>Все результаты:</b></p>
                    <ul>
                        {this.props.prev_results.map(item =>
                            <li key={item.id}>{item.name} - {item.result}</li>
                        )}
                    </ul>
                </Col>
            </Row>
        </Grid>
    }
}

function mapStateToProps(state) {
    return {
        state: state.test_result,
        get_result_success: state.get_result_success,
        prev_results: state.prev_results,
        user_authorized: state.user_authorized
    };
}

function mapDispatchToProps(dispatch) {
    return {
        getPrevResults: () => {
            dispatch(actions.getPrevResults());
        }
    }
}

module.exports = connect(mapStateToProps, mapDispatchToProps)(withRouter(Result));