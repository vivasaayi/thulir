import React, {Component} from 'react';
import { CFormSelect, CButton } from '@coreui/react';

export class CatalogBuilder extends Component {
    static displayName = CatalogBuilder.name;

    constructor(props) {
        super(props);
        this.state = {
            
        };

        this.fetchCatalog = this.fetchCatalog.bind(this);
    }

    componentDidMount() {
        
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        
    }
    
    renderRowsList() {
        const rows = [];
        for(let i=0; i < 100; i++) {
            rows.push(<option value={i}>{i}</option>)
        }

        return <CFormSelect size="sm" className="mb-3" aria-label="Small select example">
            <option>Select Row</option>
            {rows}
        </CFormSelect>
    }
    
    renderPathList() {
        const paths = [];
        for(let i=0; i < 100; i++) {
            paths.push(<option value={i}>{i}</option>)   
        }
        
        return <CFormSelect size="sm" className="mb-3" aria-label="Small select example">
            <option>Select Path</option>
            {paths}
        </CFormSelect>
    }
    
    renderContents() {
        // TODO: Generate years it programmetically
        return <div>
            <CFormSelect size="sm" className="mb-3" aria-label="Large select example">
                <option>Seect Instrument</option>
                <option value="oli-trs">oli-trs</option>
                <option value="etm">etm</option>
                <option value="tm">tm</option>
            </CFormSelect>
            
            <CFormSelect size="sm" className="mb-3" aria-label="Small select example">
                <option>Select Year</option>
                <option value="2015">2015</option>
                <option value="2016">2016</option>
                <option value="2017">2017</option>
                <option value="2018">2018</option>
                <option value="2019">2019</option>
                <option value="2020">2020</option>
                <option value="2021">2021</option>
            </CFormSelect>

            {this.renderPathList()}
            {this.renderRowsList()}

            <CButton color="primary" onClick={() => this.fetchCatalog()}>Primary</CButton>
        </div>;
    }
    
    async fetchCatalog() {
        try {
            // ToDo: This logic is also present in the server
            const response = await fetch('/api/landsatcatalogbuilder/catalog?years=2020&instruments=oli-trs&rows=100&paths=100');
            const data = await response.json();
            this.setState({catalog: data, loading: false});
        } catch(ex) {
            console.log(ex)
        }
    }
    
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderContents();
        
        

        return (
            <div>
                <h1 id="tabelLabel" >Browse Landsat Data</h1>
                {contents}
            </div>
        );
    }
}
