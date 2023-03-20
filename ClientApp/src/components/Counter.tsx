import { useState } from 'react';

export function Counter(): JSX.Element {
    const [currentCount, setCurrentCount] = useState(0);

    const incrementCounter = () => {
        setCurrentCount(currentCount + 1);
    };

    return (
        <div>            
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p aria-live="polite">Current count: <strong>{currentCount}</strong></p>

            <button type="button" className="btn btn-primary" onClick={incrementCounter}>Increment</button>
      </div>
    );
}

export default Counter;