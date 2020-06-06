import React, { Component } from 'react';
import { Container, Row, Col} from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Link } from 'react-router-dom';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
                <Row>
                    <Col xs="3">
                        <Link to="/Counter">Counter </Link>
                        <Link to="/">Home </Link>
                    </Col>
                    <Col xs="9">{this.props.children}</Col>
                </Row>
        </Container>
      </div>
    );
  }
}
