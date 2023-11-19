import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import './RegularUserPage.css';
import axios from 'axios';

export function RegularUserPage() {

    const fromTimeStamp = "0001-01-01T00:00";
    const toTimeStamp = "0001-01-01T00:00";

    const [filter, setFilter] = useState([["Level", true, ""], ["Message", true, ""], ["ResourceId", true, ""], ["FromTimeStamp", true, fromTimeStamp], ["ToTimeStamp", true, toTimeStamp], ["TraceId", true, ""], ["SpanId", true, ""], ["Commit", true, ""], ["ParentResourceId", true, ""]]);


    const navigate = useNavigate();

    const [data, setData] = useState([{
        level: "",
        message: "",
        resourceId: "",
        timestamp: "",
        traceId: "",
        spanId: "",
        commit: "",
        metadata: {
            parentResourceId: ""
        }
    }]);

    const logEntry = {
        level: filter[0][2],
        message: filter[1][2],
        resourceId: filter[2][2],
        timestamp: filter[3][2],
        traceId: filter[5][2],
        spanId: filter[6][2],
        commit: filter[7][2],
        metadata: {
            parentResourceId: filter[8][2]
        },
        totimestamp: filter[4][2],
        checkContains: true
    }


    //const sendRequests = async () => {
    //    const requests = [];

    //    for (let i = 0; i < 500000; i++) {
    //        requests.push(
    //            fetch('https://localhost:3000/app/ingest', {
    //                method: 'POST',
    //                headers: {
    //                    'Content-Type': 'application/json',
    //                },
    //                body: JSON.stringify({
    //                        level: filter[0][2],
    //                        message: filter[1][2],
    //                        resourceId: filter[2][2],
    //                        timestamp: filter[3][2],
    //                        traceId: filter[5][2],
    //                        spanId: filter[6][2],
    //                        commit: filter[7][2],
    //                        metadata: {
    //                            parentResourceId: filter[8][2]
    //                        }
    //                }),
    //            })
    //        );
    //    }

    //    try {
    //        const responses = await Promise.all(requests);
    //        const data = await Promise.all(responses.map((res) => res.json()));
    //        console.log('All requests completed successfully', data);
    //    } catch (error) {
    //        console.error('Error in one or more requests', error);
    //    }
    //};


    const onFilter = () => {

        axios.post(`https://localhost:3000/app/getfiltered`, {
            level: filter[0][2],
            message: filter[1][2],
            resourceId: filter[2][2],
            timestamp: filter[3][2],
            traceId: filter[5][2],
            spanId: filter[6][2],
            commit: filter[7][2],
            metadata: {
                parentResourceId: filter[8][2]
            },
            totimestamp: filter[4][2],
            checkContains: true
        }).then(Response => {

            setData(Response.data)
        })
    }


    const handleChange = (item, e) => {

        for (let i = 0; i < 8; i++) {
            if (filter[i][0] === item[0]) {
                filter[i][2] = e.target.value
            }
        }
        console.log(filter)
    }


    useEffect(() => {
        axios.get(`https://localhost:3000/app/getall`).then(Response => {
            console.log(Response);
            setData(Response.data)
        })
    }, []);

    useEffect(() => {

    }, [data]);


    return (

        <div className="regular-user-page-container">

            <div class="filter-container">
                {filter?.map((item) => (
                    <div className={item[1] ? "filter" : "collapse-visibility"} >
                        <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'center', gap: "10px" }}>
                            <svg xmlns="http://www.w3.org/2000/svg" height="20" viewBox="0 -960 960 960" width="20" fill="red"><path d="m336-280 144-144 144 144 56-56-144-144 144-144-56-56-144 144-144-144-56 56 144 144-144 144 56 56ZM480-80q-83 0-156-31.5T197-197q-54-54-85.5-127T80-480q0-83 31.5-156T197-763q54-54 127-85.5T480-880q83 0 156 31.5T763-763q54 54 85.5 127T880-480q0 83-31.5 156T763-197q-54 54-127 85.5T480-80Zm0-80q134 0 227-93t93-227q0-134-93-227t-227-93q-134 0-227 93t-93 227q0 134 93 227t227 93Zm0-320Z" /></svg>
                            <div className="filter-box-text" >{item[0]}</div>
                        </div>
                        {item[0] === "FromTimeStamp" || item[0] === "ToTimeStamp" ? <input className="filter-box-text" onChange={(e) => { handleChange(item, e) }} type="datetime-local" ></input> :
                            <input className="filter-box-text" onChange={(e) => { handleChange(item, e) }}></input>}
                    </div>
                ))}

                <div class="add-filter-button">
                    + Add Filter
                </div>
            </div>
            <div style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between', paddingLeft: "50px", paddingRight: "50px" }} >

                <div class="add-filter-button" onClick={() => onFilter()} >
                    Submit
                </div>
            </div>
            <div style={{ marginTop: "17px" }}>
                <table >
                    <thead>
                        <tr>
                            <th>Level</th>
                            <th>Message</th>
                            <th>Resource ID</th>
                            <th>Timestamp</th>
                            <th>Trace ID</th>
                            <th>Span ID</th>
                            <th>Commit</th>
                            <th>Metadata</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data?.map((item) => (
                            <tr>
                                <td>{item.level}</td>
                                <td>{item.message}</td>
                                <td>{item.resourceId}</td>
                                <td>{item.timestamp}</td>
                                <td>{item.traceId}</td>
                                <td>{item.spanId}</td>
                                <td>{item.commit}</td>
                                <td>{item.metadata.parentResourceId}</td>
                            </tr>))}
                    </tbody>
                </table>
            </div>

        </div>

    );
}
