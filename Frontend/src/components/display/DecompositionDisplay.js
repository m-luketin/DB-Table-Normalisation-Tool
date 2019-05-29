import React from 'react';

const DecompositionDisplay = ({table}) =>{
    return(
        <div className="Table">
            <div className="TableAttributes">
                {
                    table.map((attribute,index)=>{
                        return <>{attribute}</>
                    })
                }
            </div>
        </div>
    )
}
export default DecompositionDisplay;