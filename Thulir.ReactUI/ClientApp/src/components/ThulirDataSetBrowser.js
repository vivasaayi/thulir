import React, {Component} from 'react';

import {DataSetDetails} from "./ThulirDataSets/DataSetDetails";

export class ThulirDataSetBrowser extends Component {
    static displayName = ThulirDataSetBrowser.name;

    constructor(props) {
        super(props);
        this.state = {
            catalog: undefined, 
            loading: true,
            catalogName: "",
            dataSetName: undefined
        };
        
        this.exploreCatalog = this.exploreCatalog.bind(this);
    }

    componentDidMount() {
        this.fetchCatalog();
    }
    
    componentDidUpdate(prevProps, prevState, snapshot) {
        //debugger;
        if(this.state.catalogName !== prevState.catalogName) {
            this.fetchCatalog();    
        }
    }

    renderCatalog(catalog) {
        return (
            <div>
                <h3>Stac Version: {catalog.stac_version}</h3>
                <h3>Id: {catalog.id}</h3>
                <h3>Description: {catalog.description}</h3>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Link Type</th>
                        <th>Title</th>
                        <th>Link</th>
                        <th>Action</th>
                    </tr>
                    </thead>
                    <tbody>
                    {catalog.links.map(link =>
                        <tr key={link.href}>
                            <td>{link.rel}</td>
                            <td>{link.title}</td>
                            <td>{link.href}</td>
                            <td><span onClick={() => this.exploreCatalog(link)}>Explore</span></td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>
        );
    }

    exploreCatalog(event) {
        console.log(event)
        
        if(event.href.endsWith("catalog.json")) {
            this.setState({catalogName: event.href});    
        } else if(event.href.endsWith("stac.json")) {
            this.setState({catalogName: event.href});
        }
    }

    handleButtonClick(e) {
        this.setState({dataSetName: e.target.innerText} )
        this.renderDataSetDetail(e.target.innerText)
    }
    
    renderDataSetDetail() {
        if(this.state.dataSetName && this.state.dataSetName !== ""){
            debugger
            return <DataSetDetails data={this.state.dataSetName}/>;
        }
    }
    
    renderDataSets(dataSets) {
        let dataSetsTags = [];

        dataSets.forEach((ds) => {
            dataSetsTags.push(<button type="button" className="btn btn-primary" 
                onClick={this.handleButtonClick.bind(this)}>{ds}</button>)
        })
        
        return (<div>
            {dataSetsTags}    
        </div>)
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderDataSets(this.state.datasets);

        return (
            <div>
                <h1 id="tabelLabel" >Browse Available DataSets</h1>
                {contents}

                {this.renderDataSetDetail()}
            </div>
        );
    }

    async fetchCatalog() {
        try {
            const response = await fetch('/api/thulirdataset/available-data-sets');
            const data = await response.json();
            this.setState({datasets: data, loading: false});    
        } catch(ex) {
            console.log(ex);
        }
    }
}
