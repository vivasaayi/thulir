import React, {Component} from 'react';
import {
    CForm,
    CFormSelect,
    CButton,
    CFormLabel,
    CFormInput,
    CRow,
    CCol,
    CContainer,
    CCard,
    CCardImage
} from '@coreui/react';

const cardImageCss = {
    "padding": "2px"
}

export class TileGenerator extends Component {
    static displayName = TileGenerator.name;

    constructor(props) {
        super(props);
        this.state = {
            file: "LC08_L2SP_143054_20210106_20210309_02_T1"
        };
    }

    componentDidMount() {

    }

    componentDidUpdate(prevProps, prevState, snapshot) {

    }

    renderControls() {
        // TODO: Generate years it programmatically
        return <div>
            <CForm>
                <CContainer>
                    <CRow>
                        <CCol size="sm">
                            <CButton color="primary" onClick={() => this.generateTiles()}>Generate Tiles</CButton>
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

    async generateTiles() {
        try {
            const response = await fetch(`/api/landsattilegenerator/generate-tiles`);
            const data = await response.json();
            this.setState({pendingFiles: data, loading: false});
        } catch (ex) {
            console.log(ex)
        }
    }

    renderBands() {
        return <CRow>
            <CCol>
                <CCard style={{width: '10rem', 'flex-direction': 'row'}}>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B1.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B2.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B3.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B4.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B5.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B6.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_SR_B7.png`}/>
                    <CCardImage style={cardImageCss} orientation="top" src={`/landsat-tile/${this.state.file}_ST_B10.png`}/>
                </CCard>
            </CCol>
        </CRow>
    }

    render() {
        let controls = this.renderControls();
        let bands = this.renderBands();

        return (
            <div>
                <h1>Catalog Builder</h1>
                <h5>Use this page to build catalogs</h5>
                <hr/>
                {controls}
                <hr/>
                {bands}
            </div>
        );
    }
}
