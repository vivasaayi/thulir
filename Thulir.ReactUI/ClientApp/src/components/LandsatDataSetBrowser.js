import React, {Component} from 'react';

export class LandsatDataSetBrowser extends Component {
    static displayName = LandsatDataSetBrowser.name;

    constructor(props) {
        super(props);
        this.state = {catalog: undefined, loading: true};
    }

    componentDidMount() {
        this.fetchCatalog();
    }

    static renderCatalog(catalog) {
        return (
            <div>
                <h3>catalog.stac_version</h3>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Link Type</th>
                        <th>Title</th>
                        <th>Link</th>
                    </tr>
                    </thead>
                    <tbody>
                    {catalog.links.map(link =>
                        <tr key={link.href}>
                            <td>{link.rel}</td>
                            <td>{link.title}</td>
                            <td>{link.href}</td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : LandsatDataSetBrowser.renderCatalog(this.state.catalog);

        return (
            <div>
                <h1 id="tabelLabel" >Browse Landsat Data</h1>
                {contents}
            </div>
        );
    }

    async fetchCatalog() {
        const response = await fetch('/api/landsatawsdataset/catalog');
        const data = await response.json();
        this.setState({catalog: data, loading: false});
    }
}
