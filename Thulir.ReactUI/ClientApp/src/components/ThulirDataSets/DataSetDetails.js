import React, {Component} from 'react';

export class DataSetDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            dataSetName: "",
            setSelectedLabel: ""
        };
    }

    componentDidMount() {
        this.fetchLabels();
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        //debugger;
        if(this.state.catalogName !== prevState.catalogName) {
            this.fetchCatalog();
        }
        
        if(this.state.setSelectedLabel !== prevState.setSelectedLabel) {
            this.fetchImagesForLabel();
        }
    }

    handleButtonClick(e){
        this.setState({
            setSelectedLabel: e.target.innerText
        })
    }

    renderLabels() {
        if(this.state.labels) {
            const renderedLabels = [];
            
            this.state.labels.forEach((label) => {
                renderedLabels.push(
                    <button type="button" className="btn btn-secondary"
                            onClick={this.handleButtonClick.bind(this)}>{label}</button>
                )
            })
            
            return renderedLabels;
        } else {
            return <h4>No Labels Found for this dataset</h4>
        }
    }

    render() {
        
        return (
            <div>
                <h1 id="tabelLabel" >DataSet: {this.props.data}</h1>
                {this.renderLabels()}
            </div>
        );
    }

    async fetchLabels() {
        try {
            const response = await fetch('/api/thulirdataset/labels?dataset=' + this.props.data);
            const data = await response.json();
            this.setState({labels: data, loading: false});
        } catch(ex) {
            console.log(ex);
        }
    }

    async fetchImagesForLabel() {
        try {
            const response = await fetch('/api/thulirdataset/images?label=' + this.state.setSelectedLabel);
            const data = await response.json();
            this.setState({labels: data, loading: false});
        } catch(ex) {
            console.log(ex);
        }
    }
}
