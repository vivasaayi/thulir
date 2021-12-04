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

export class CatalogBuilder extends Component {
    static displayName = CatalogBuilder.name;

    constructor(props) {
        super(props);
        this.state = {
            instrument: "oli-tirs",
            years: "2019,2020,2021",
            paths: "144",
            rows: "052"
        };

        this.fetchCatalog = this.fetchCatalog.bind(this);
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps, prevState, snapshot) {

    }

    renderRowsList() {
        const rows = [];
        for (let i = 0; i < 100; i++) {
            rows.push(<option value={i}>{i}</option>)
        }

        return <CFormSelect size="sm" className="mb-3" aria-label="Small select example">
            <option>Select Row</option>
            {rows}
        </CFormSelect>
    }

    renderPathList() {
        const paths = [];
        for (let i = 0; i < 100; i++) {
            paths.push(<option value={i}>{i}</option>)
        }

        return <CFormSelect size="sm" className="mb-3" aria-label="Small select example">
            <option>Select Path</option>
            {paths}
        </CFormSelect>
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
        // TODO: Generate years it programmetically
        return <div>
            <CForm>
                <CContainer>
                    <CRow>
                        <CCol>
                            <div className="mb-3">
                                <CFormLabel htmlFor="instrument">Instruments</CFormLabel>
                                <CFormSelect id="instrument" size="sm" aria-label="Large select example"
                                             value={this.state.instrument} onChange={(e) => this.onInstrumentChange(e)}>
                                    <option>Select Instrument</option>
                                    <option value="oli-tirs">oli-tirs</option>
                                    <option value="etm">etm</option>
                                    <option value="tm">tm</option>
                                </CFormSelect>
                            </div>
                        </CCol>


                        <CCol>
                            <div className="mb-3">
                                <CFormLabel htmlFor="years">Years</CFormLabel>
                                <CFormInput id="years" value={this.state.years} onChange={(e) => this.onYearChange(e)}/>
                            </div>
                        </CCol>

                        <CCol>
                            <div className="mb-3">
                                <CFormLabel htmlFor="paths">Paths</CFormLabel>
                                <CFormInput id="paths" value={this.state.paths}
                                            onChange={(e) => this.onPathsChange(e)}/>
                            </div>
                        </CCol>

                        <CCol>
                            <div className="mb-3">
                                <CFormLabel htmlFor="row">Rows</CFormLabel>
                                <CFormInput id="row" value={this.state.rows} onChange={(e) => this.onRowsChange(e)}/>
                            </div>
                        </CCol>

                        {/*{this.renderPathList()}*/}
                        {/*{this.renderRowsList()}*/}
                    </CRow>
                    <CRow>
                        <CCol size="md">
                            <CButton color="primary" onClick={() => this.fetchCatalog()}>Fetch Catalog</CButton>
                        </CCol>
                    </CRow>
                </CContainer>
            </CForm>

        </div>;
    }

    onInstrumentChange(event) {
        this.setState({
            instrument: event.target.value
        });
    }

    onYearChange(event) {
        this.setState({
            years: event.target.value
        });
    }

    onPathsChange(event) {
        this.setState({
            paths: event.target.value
        });
    }

    onRowsChange(event) {
        this.setState({
            rows: event.target.value
        });
    }

    getQueryParams() {
        return `years=${this.state.years}&instruments=${this.state.instrument}&rows=${this.state.rows}&paths=${this.state.paths}`
    }

    async fetchCatalog() {
        try {
            // ToDo: This logic is also present in the server
            const response = await fetch(`/api/landsatcatalogbuilder/catalog?${this.getQueryParams()}`);
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
