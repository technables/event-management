import React, { Fragment } from 'react';

const Home = () => {
    return (
        <Fragment>

            <div className="col-md-12" style={{ marginTop: '10px' }}>
                <div className="alert alert-dismissible alert-info">
                    <h4 className="alert-heading">Info!</h4>
                    <p className="mb-0">
                        Hi! Our coronavirus disease self assessment scan has been developed on the basis of guidelines from the WHO and MoH, Government of Nepal. This interaction should not be taken as expert medical advice. Any information you share with us will be kept strictly confidential.
                    </p>
                </div>
            </div>
        </Fragment>
    )
}

export default Home;