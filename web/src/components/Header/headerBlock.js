import React from 'react';
import UserName from './userName';

export default class HeaderBlock extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: "Vasily!"
        }
    }

    componentDidMount() {
        this.timerId = setInterval(
            () => {
                this.setState({
                    name: (this.state.name + "."),
                });
            },
            1000
        )
    }

    render() {
        let boolresult = false;
        return (
            <div>
                {boolresult &&
                    <UserName name={this.state.name} />
                }
            </div>
        );
    }
}