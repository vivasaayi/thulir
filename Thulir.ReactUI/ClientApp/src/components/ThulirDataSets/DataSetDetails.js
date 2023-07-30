import React, {Component} from 'react';

export class DataSetDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            dataSetName: this.props.data,
            setSelectedLabel: ""
        };
    }

    componentDidMount() {
        debugger;
        this.setState({
            dataSetName: this.props.data
        })
        this.fetchLabels();
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        debugger;
        
        if(this.state.dataSetName !== prevState.dataSetName) {
            this.fetchLabels();
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

    renderImages() {
        debugger
        if(!this.state.images) {
            return;
        }
        const renderedImages = [];

        this.state.images.forEach((image) => {
            const imageSplit = image.split("/");
            const dataSetName = imageSplit[0];
            const label = imageSplit[1];
            const fileName = imageSplit[2];
            
            renderedImages.push(
                <div class="row">
                    <div class="col-2">
                        <img width={200} height={200} src={"/img/" + image}></img>
                    </div>
                    <div className="col-8">
                        <div>FileName: {fileName}</div>
                        <div>DataSetName: {dataSetName}</div>
                        <div>Label: {label}</div>
                    </div>
                </div>
            )
        })

        return renderedImages;
    }

    render() {
        debugger;
        
        if(this.state.dataSetName !== this.props.data) {
            this.setState({
                dataSetName: this.props.data
            })
        }
        
        return (
            <div>
                <h1 id="tabelLabel" >DataSet: {this.props.data}</h1>
                {this.renderLabels()}
                {this.renderImages()}
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
            let url = '/api/thulirdataset/images?label=' + this.state.setSelectedLabel
            url += "&dataset=" + this.state.dataSetName;
            const response = await fetch(url);
            const images = await response.json();
            this.setState({images: images, loading: false});
            console.log(images)
        } catch(ex) {
            console.log(ex);
        }
    }
}
