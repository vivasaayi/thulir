import React, {Component} from 'react';
import {
    CForm,
    CFormSelect,
    CButton,
    CFormLabel,
    CFormInput,
    CRow,
    CCol,
    CContainer
} from '@coreui/react';

export class LocalizeS3Data extends Component {
    static displayName = LocalizeS3Data.name;

    constructor(props) {
        super(props);
        this.state = {
            pendingFiles: ""
        };

        this.fetchCatalog = this.fetchCatalog.bind(this);
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps, prevState, snapshot) {

    }


    renderCatalog(catalog) {
        if(!catalog){
            return <div>Catalog Not Loaded</div>
        }

        return (
            <div>
                <h3>Stac Version: {catalog.stac_version}</h3>
                <h3>Id: {catalog.id}</h3>
                <h3>Description: {catalog.description}</h3>

                <h3>Total Items: {catalog.links.length}</h3>

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

    renderControls() {
        // TODO: Generate years it programmatically
        return <div>
            <CForm>
                <CContainer>
                    <CRow>
                        <CCol size="sm">
                            <CButton color="primary" onClick={() => this.fetchCatalog()}>Fetch Catalog</CButton> 
                            <CButton color="primary" onClick={() => this.localizeS3Files()}>Localize S3 files</CButton>
                        </CCol>
                    </CRow>
                    <CRow>
                        <CCol size="sm">
                            {JSON.stringify(this.state.pendingFiles)}
                        </CCol>
                    </CRow>
                </CContainer>
            </CForm>

        </div>;
    }

    async localizeS3Files() {
        try {
            const response = await fetch(`/api/landsatawsdataset/catalog/sync-s3`);
            const data = await response.json();
            this.setState({pendingFiles: data, loading: false});
        } catch (ex) {
            console.log(ex)
        }
    }

    async fetchCatalog() {
        try {
            const response = await fetch(`/api/landsatcatalogbuilder/indexed-catalog`);
            const data = await response.json();
            this.setState({catalog: data, loading: false});
        } catch (ex) {
            console.log(ex)
        }
    }

    render() {
        let controls = this.renderControls();

        let catalog = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCatalog(this.state.catalog);


        return (
            <div>
                <h1>Catalog Builder</h1>
                <h5>Use this page to build catalogs</h5>
                <hr/>
                {controls}
                <hr/>
                {catalog}
            </div>
        );
    }
}
