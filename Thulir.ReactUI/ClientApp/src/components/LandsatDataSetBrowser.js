import React, {Component} from 'react';

export class LandsatDataSetBrowser extends Component {
    static displayName = LandsatDataSetBrowser.name;

    constructor(props) {
        super(props);
        this.state = {
            catalog: undefined, 
            loading: true,
            catalogName: ""
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

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCatalog(this.state.catalog);

        return (
            <div>
                <h1 id="tabelLabel" >Browse Landsat Data</h1>
                {contents}
            </div>
        );
    }

    async fetchCatalog() {
        try {
            // ToDo: This logic is also present in the server
            const s3KeyName = this.state.catalogName.replace("https://landsatlook.usgs.gov/data/", "");
            console.log("Fetching data..", s3KeyName)
            const response = await fetch('/api/landsatawsdataset/catalog?name=' + s3KeyName);
            const data = await response.json();
            this.setState({catalog: data, loading: false});    
        } catch(ex) {
            console.log(ex)
        }
    }
}
