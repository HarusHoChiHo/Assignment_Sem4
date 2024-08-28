import {useState} from "react";
import PropTypes from "prop-types";

export default function Counter() {
    const [state, setState] = useState(0);
    return (
        <>
            <span className="count">{state}</span>
            <CounterButton by={1} update={setState}/>
            <CounterButton by={2} update={setState}/>
            <CounterButton by={5} update={setState}/>
        </>
    )
}

function CounterButton({by, update}) {
    
    function incrementCounter() {
        update((state) => state + by)
    }

    function decrermentCounter() {
        update((state) => state - by)
    }

    return (
        <>
            <div className={"CounterButton"}>
                <div>
                    <button
                        className={"counterButton"}
                        onClick={incrementCounter}
                    >+{by}
                    </button>
                    <button
                        className={"counterButton"}
                        onClick={decrermentCounter}
                    >-{by}
                    </button>
                </div>

            </div>
        </>
    );
}

CounterButton.propType = {
    by: PropTypes.number,
    update: PropTypes.func
}

CounterButton.defaultProps = {
    by: 1,
    update: null
}